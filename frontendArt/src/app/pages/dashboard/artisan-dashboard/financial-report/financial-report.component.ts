import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../../service/order/order.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface ReportRow {
  label: string;
  amount: number;
}

@Component({
  selector: 'app-financial-report',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './financial-report.component.html',
  styleUrls: ['./financial-report.component.css']
})
export class FinancialReportComponent implements OnInit {

  periods = [
    { label: 'This week', value: 'week' },
    { label: 'This month', value: 'month' },
    { label: "This year", value: 'year' }
  ];

  selectedPeriod: 'week' | 'month' | 'year' = 'week';  report: ReportRow[] = [];
  loading = false;
  error = '';

  constructor(private orderSvc: OrderService) { }

  ngOnInit() {
    this.loadReport();
  }

  loadReport() {
    this.loading = true;
    this.error = '';
    this.orderSvc.getRevenue(this.selectedPeriod)
      .subscribe({
        next: (rows: ReportRow[]) => {
          this.report = rows || [];
          this.loading = false;
        },
        error: (err: any) => {
          console.error(err);
          this.error = 'Cannot load report.';
          this.loading = false;
        }
      });
  }

  onPeriodChange(period: 'week' | 'month' | 'year') {
    this.selectedPeriod = period;
    this.loadReport();
  }
  get total(): number {
    if (!this.report || !Array.isArray(this.report)) {
      return 0;
    }
    return this.report.reduce((sum, row) => sum + (row.amount ?? 0), 0);
  }
}
