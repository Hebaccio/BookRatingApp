import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule, RouterOutlet} from "@angular/router";

import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { DataEditorComponent } from './data-editor/data-editor.component';
import { DataBasicsComponent } from './data-basics/data-basics.component';
import { DataBookComponent } from './data-book/data-book.component';
import { DataPersonComponent } from './data-person/data-person.component';

const routes : Routes = [
  {path: '', redirectTo: '/Home', pathMatch: 'full'},
  {path: 'Home', component: HomeComponent},
  {path: 'DatabaseEditor', component: DataEditorComponent,
  children:[
  {path: '', redirectTo: 'Basics', pathMatch: 'full'},
    {path: 'Basics', component: DataBasicsComponent},
    {path: 'Book', component: DataBookComponent},
    {path: 'Person', component: DataPersonComponent},
]}
];

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    NavbarComponent,
    HomeComponent,
    DataEditorComponent,
    DataBasicsComponent,
    DataBookComponent,
    DataPersonComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot( routes,{scrollPositionRestoration: 'enabled'}),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
