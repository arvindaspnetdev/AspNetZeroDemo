import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCountryDialogComponent } from './edit-country-dialog.component';

describe('EditCountryDialogComponent', () => {
  let component: EditCountryDialogComponent;
  let fixture: ComponentFixture<EditCountryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCountryDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCountryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
