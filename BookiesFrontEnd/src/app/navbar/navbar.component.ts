import { Component, HostListener, OnInit, Renderer2 } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(private router: Router, private renderer:Renderer2) {}

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
