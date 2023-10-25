import { Component, HostListener, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-data-editor',
  templateUrl: './data-editor.component.html',
  styleUrls: ['./data-editor.component.css']
})
export class DataEditorComponent implements OnInit{

  previousScrollPos: number = 0;
  isFixed:boolean=true;

  ngOnInit(){
    this.isFixed = true;
    this.previousScrollPos = window.scrollY;
  }

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event): void {
    const currentScrollPos = window.scrollY;

    if (currentScrollPos > this.previousScrollPos) {
      this.isFixed=false;
    } else {
      //this.renderer.setStyle(this.el.nativeElement.querySelector('.main-container'), 'opacity', 1);
      this.isFixed=true;
    }
    this.previousScrollPos = currentScrollPos;
  }

  constructor(private router: Router) { }

  OpenPerson() {
    this.router.navigateByUrl("DatabaseEditor/Person");
  }

  OpenBook() {
    this.router.navigateByUrl("DatabaseEditor/BookAdd");
  }

  OpenBasics() {
    this.router.navigateByUrl("DatabaseEditor/Basics");
  }
}
