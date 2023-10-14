import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBookComponent } from './data-book.component';

describe('DataBookComponent', () => {
  let component: DataBookComponent;
  let fixture: ComponentFixture<DataBookComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataBookComponent]
    });
    fixture = TestBed.createComponent(DataBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
