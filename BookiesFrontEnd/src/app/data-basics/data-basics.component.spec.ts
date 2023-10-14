import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBasicsComponent } from './data-basics.component';

describe('DataBasicsComponent', () => {
  let component: DataBasicsComponent;
  let fixture: ComponentFixture<DataBasicsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataBasicsComponent]
    });
    fixture = TestBed.createComponent(DataBasicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
