import {Component, HostListener, OnInit} from '@angular/core';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  previousScrollPos: number = 0;
  isFixed:boolean=true;

  ngOnInit() {
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

}
