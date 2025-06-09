import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtisanInquiriesComponent } from './artisan-inquiries.component';

describe('ArtisanInquiriesComponent', () => {
  let component: ArtisanInquiriesComponent;
  let fixture: ComponentFixture<ArtisanInquiriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtisanInquiriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtisanInquiriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
