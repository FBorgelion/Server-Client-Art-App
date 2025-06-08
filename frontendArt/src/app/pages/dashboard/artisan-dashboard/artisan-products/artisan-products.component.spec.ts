import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtisanProductsComponent } from './artisan-products.component';

describe('ArtisanProductsComponent', () => {
  let component: ArtisanProductsComponent;
  let fixture: ComponentFixture<ArtisanProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtisanProductsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtisanProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
