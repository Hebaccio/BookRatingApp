import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Bookies';

  isFixed = true;

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event): void {
    let currentScrollPos = window.scrollY;

    window.addEventListener("scroll", ()=>{
      if (currentScrollPos > window.scrollY) {
        // Scrolling up, show the component
        this.isFixed = true;
      } else {
        // Scrolling down, hide the component
        this.isFixed = false;
      }

    })
  }

}
