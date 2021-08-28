import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateStateDialogComponent } from './create-state-dialog.component';

describe('CreateStateDialogComponent', () => {
  let component: CreateStateDialogComponent;
  let fixture: ComponentFixture<CreateStateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateStateDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateStateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
