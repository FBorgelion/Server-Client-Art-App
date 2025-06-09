import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../../service/authentication/authentication.service';
import { InquiryDTO, InquiryService } from '../../../../service/inquiries/inquiry.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-artisan-inquiries',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './artisan-inquiries.component.html',
  styleUrl: './artisan-inquiries.component.css'
})
export class ArtisanInquiriesComponent implements OnInit {

  inquiries: any[] = [];
  loading = false;
  error = '';
  artisanId!: number;

  constructor(
    private inqService: InquiryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.artisanId = id;
    this.loadInquiries();
  }

  loadInquiries() {
    this.loading = true;
    this.inqService.getForArtisan()
      .subscribe({
        next: list => { this.inquiries = list; this.loading = false; },
        error: err => { console.error(err); this.error = 'Error loading'; this.loading = false; }
      });
  }

  respond(inq: InquiryDTO) {
    const resp = inq.response?.trim();
    console.log('Réponse:', resp);
    if (!resp) {
      alert('Response cannot be empty.');
      return;
    }

    this.inqService.respond(inq.inquiryId, resp)
      .subscribe({
        next: () => {
          inq.response = resp;
          alert('Response registered.');
        },
        error: () => {
          alert('Cannot register response.');
        }
      });
  }

  delete(inq: InquiryDTO) {
    if (!confirm('Do you really want to delete this inquiry ?')) return;
    this.inqService.deleteInquiry(inq.inquiryId).subscribe({
      next: () => {
        this.inquiries = this.inquiries.filter(i => i.inquiryId !== inq.inquiryId);
      },
      error: err => {
        console.error(err);
        alert('Cannot delete inquiry.');
      }
    });
  }

}
