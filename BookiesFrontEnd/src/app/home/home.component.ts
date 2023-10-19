import {Component, HostListener, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  previousScrollPos: number = 0;
  isFixed:boolean=true;

  constructor(private router: Router) {}

  ngOnInit() {
    this.isFixed = true;
    this.previousScrollPos = window.scrollY;
  }

  OpenDatabaseEditor() {
    this.router.navigateByUrl("DatabaseEditor");
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

}
