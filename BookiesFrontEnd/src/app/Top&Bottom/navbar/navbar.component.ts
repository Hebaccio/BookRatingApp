import { Component, HostListener, Renderer2, ViewChild, ElementRef, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  previousScrollPos: number = 0;

  constructor(private renderer:Renderer2, private el:ElementRef) {
  }

  ngOnInit() {
    this.previousScrollPos = window.scrollY;
  }
  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event): void {
    const currentScrollPos = window.scrollY;

    if(window.innerWidth>900){
      const scrollNavbar = this.el.nativeElement.querySelector('.ScrollNavbar');
      const dropdownContent: null = this.el.nativeElement.querySelector('.dropdown-content');

      //If we don't have login
      if(dropdownContent!=null){
        if (currentScrollPos > this.previousScrollPos) {
          // Scrolling down
          this.renderer.setStyle(dropdownContent, 'transition', '0.7s ease-in-out');
          this.renderer.setStyle(scrollNavbar, 'top', '-180px');
          this.renderer.setStyle(scrollNavbar, 'transition', '0.7s ease-in-out');
        } else {
          // Scrolling up
          this.renderer.setStyle(scrollNavbar, 'top', '0px');
          this.renderer.setStyle(scrollNavbar, 'transition', '0.7s ease-in-out');
        }
      } else { //If we have login
        if (currentScrollPos > this.previousScrollPos) {
          // Scrolling down
          this.renderer.setStyle(scrollNavbar, 'top', '-180px');
          this.renderer.setStyle(scrollNavbar, 'transition', '0.7s ease-in-out');
        } else {
          // Scrolling up
          this.renderer.setStyle(scrollNavbar, 'top', '0px');
          this.renderer.setStyle(scrollNavbar, 'transition', '0.7s ease-in-out');
        }
      }

    }
    else{
      const top = this.el.nativeElement.querySelector('.Top');
      const scrollNavbar = this.el.nativeElement.querySelector('.ScrollNavbar');
      const dropdownContent: null = this.el.nativeElement.querySelector('.dropdown-content');

      if (currentScrollPos > this.previousScrollPos) {
        // Scrolling down
        this.renderer.setStyle(top, 'top', '-125px');
        this.renderer.setStyle(scrollNavbar, 'bottom', '-180px');
        this.renderer.setStyle(top, 'transition', '0.7s ease-in-out');
        this.renderer.setStyle(scrollNavbar, 'transition', '0.7s ease-in-out');
      } else {
        // Scrolling up
        this.renderer.setStyle(top, 'top', '0px');
        this.renderer.setStyle(scrollNavbar, 'bottom', '0px');
      }
    }

    this.previousScrollPos = currentScrollPos;
  }
}
