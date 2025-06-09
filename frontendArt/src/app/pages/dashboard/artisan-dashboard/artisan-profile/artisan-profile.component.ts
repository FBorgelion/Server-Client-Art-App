import { Component, OnInit } from '@angular/core';
import { ArtisanService } from '../../../../service/artisan/artisan.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-artisan-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './artisan-profile.component.html',
  styleUrl: './artisan-profile.component.css'
})
export class ArtisanProfileComponent implements OnInit {

  artisan: any;
  editing: boolean = false;
  description = "";
  artisanId!: number ;

  constructor(private service: ArtisanService, private route: ActivatedRoute) {
  
  }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.artisanId = idParam ? +idParam : 0;
    this.loadProfile();
  }

  loadProfile() {
    this.service.getArtisan()
      .subscribe(p => {
        this.artisan = p;
        this.description = p.profileDescription;
      });
    console.log(this.description);
  }

  startEdit() {
    this.editing = true;
  }

  save() {
    this.service.updateDescription(this.description)
      .subscribe({
        next: () => {
          this.artisan.profileDescription = this.description;
          this.editing = false;
          this.loadProfile();
        },
        error: err => {
          console.error(err);
          alert('Impossible de mettre à jour.');
        }
      });
  }

  cancel() {
    this.editing = false;
    this.description = this.artisan.profileDescription;
  }

}
