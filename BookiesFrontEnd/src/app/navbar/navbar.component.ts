import { Component, HostListener, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  constructor(private router: Router) {}
  isFixed: boolean = true;
  previousScrollPos: number = 0;

  ngOnInit() {
    this.isFixed = true;
    this.previousScrollPos = window.scrollY;
  }

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event): void {
    const currentScrollPos = window.scrollY;

    if (currentScrollPos > this.previousScrollPos) {
      // Scrolling down, hide the component
      this.isFixed = false;
    } else {
      // Scrolling up, show the component
      this.isFixed = true;
    }

    this.previousScrollPos = currentScrollPos;
  }
  OpenHome() {
    this.router.navigateByUrl("Home");
  }
  OpenDatabaseEditor() {
    this.router.navigateByUrl("DatabaseEditor");
  }
  LogOut() {
    this.router.navigateByUrl("Home");
  }
}
