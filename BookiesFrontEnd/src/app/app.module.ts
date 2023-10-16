import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { Routes, RouterModule, RouterOutlet} from "@angular/router";

import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { DataEditorComponent } from './database/data-editor/data-editor.component';
import { DataBasicsComponent } from './database/data-basics/data-basics.component';
import { DataBookComponent } from './database/data-book/data-book.component';
import { DataPersonComponent } from './database/data-person/data-person.component';
import {FormsModule} from "@angular/forms";

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
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'}),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
