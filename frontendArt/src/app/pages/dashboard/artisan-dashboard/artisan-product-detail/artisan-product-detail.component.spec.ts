import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtisanProductDetailComponent } from './artisan-product-detail.component';

describe('ArtisanProductDetailComponent', () => {
  let component: ArtisanProductDetailComponent;
  let fixture: ComponentFixture<ArtisanProductDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtisanProductDetailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtisanProductDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
