import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve product items from the server', () => {
    const mockProductItems = [
      { date: '2021-10-01', price: 20, size: 68, type: 'Mild' },
      { date: '2021-10-02', price: 25, size: 77, type: 'Warm' }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/ProductItems');
    expect(req.request.method).toEqual('GET');
    req.flush(mockProductItems);

    expect(component.productItems).toEqual(mockProductItems);
  });
});
