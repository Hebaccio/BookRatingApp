import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { Routes, RouterModule, RouterOutlet} from "@angular/router";

import { AppComponent } from './app.component';
import { BookComponent } from './basics/book/book.component';
import { NavbarComponent } from './Top&Bottom/navbar/navbar.component';
import { HomeComponent } from './basics/home/home.component';
import { DataEditorComponent } from './database/data-editor/data-editor.component';
import { DataBasicsComponent } from './database/data-basics/data-basics.component';
import { DataBookComponent } from './database/data-book/data-book.component';
import { DataPersonComponent } from './database/data-person/data-person.component';
import { FormsModule } from "@angular/forms";
import { FooterComponent } from './Top&Bottom/footer/footer.component';
import { LogInComponent } from './registration/log-in/log-in.component';
import { SignUpComponent } from './registration/sign-up/sign-up.component';

const routes : Routes = [
  {path: '', redirectTo: '/Home', pathMatch: 'full'},
  {path: 'Home', component: HomeComponent},
  {path: 'LogIn', component: LogInComponent},
  {path: 'SignUp', component: SignUpComponent},
  {path: 'Book', component: BookComponent},
  {path: 'DatabaseEditor', component: DataEditorComponent,
  children:[
  {path: '', redirectTo: 'Basics', pathMatch: 'full'},
    {path: 'Basics', component: DataBasicsComponent},
    {path: 'BookAdd', component: DataBookComponent},
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
    DataPersonComponent,
    FooterComponent,
    LogInComponent,
    SignUpComponent,
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
