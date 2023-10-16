import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataPersonComponent } from './data-person.component';

describe('DataPersonComponent', () => {
  let component: DataPersonComponent;
  let fixture: ComponentFixture<DataPersonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataPersonComponent]
    });
    fixture = TestBed.createComponent(DataPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
