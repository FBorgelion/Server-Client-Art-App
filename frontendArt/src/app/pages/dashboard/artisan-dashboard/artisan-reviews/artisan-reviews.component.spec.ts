import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtisanReviewsComponent } from './artisan-reviews.component';

describe('ArtisanReviewsComponent', () => {
  let component: ArtisanReviewsComponent;
  let fixture: ComponentFixture<ArtisanReviewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtisanReviewsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtisanReviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
