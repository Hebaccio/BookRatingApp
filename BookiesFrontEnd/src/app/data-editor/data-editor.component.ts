import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-data-editor',
  templateUrl: './data-editor.component.html',
  styleUrls: ['./data-editor.component.css']
})
export class DataEditorComponent {

  constructor(private router: Router) { }

  OpenPerson() {
    this.router.navigateByUrl("DatabaseEditor/Person");
  }

  OpenBook() {
    this.router.navigateByUrl("DatabaseEditor/Book");
  }

  OpenBasics() {
    this.router.navigateByUrl("DatabaseEditor/Basics");
  }
}
