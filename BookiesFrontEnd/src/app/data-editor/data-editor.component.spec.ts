import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataEditorComponent } from './data-editor.component';

describe('DataEditorComponent', () => {
  let component: DataEditorComponent;
  let fixture: ComponentFixture<DataEditorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataEditorComponent]
    });
    fixture = TestBed.createComponent(DataEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
