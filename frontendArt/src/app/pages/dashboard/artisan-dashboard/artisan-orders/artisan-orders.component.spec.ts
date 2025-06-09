import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ArtisanOrdersComponent } from './artisan-orders.component';

describe('ArtisanOrdersComponent', () => {
  let component: ArtisanOrdersComponent;
  let fixture: ComponentFixture<ArtisanOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtisanOrdersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtisanOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
