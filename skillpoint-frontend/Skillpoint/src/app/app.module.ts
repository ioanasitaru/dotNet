import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { IntroSectionComponent } from './components/intro-section/intro-section.component';
import { FooterComponent } from './components/footer/footer.component';
import { EventsSectionComponent } from './components/events-section/events-section.component';
import { LeaderboardSectionComponent } from './components/leaderboard-section/leaderboard-section.component';
import { FutureEventsSectionComponent } from './components/future-events-section/future-events-section.component';
import { PastEventsSectionComponent } from './components/past-events-section/past-events-section.component';
import { AboutWebsiteComponent } from './components/about-website/about-website.component';
import { AboutLocationComponent } from './components/about-location/about-location.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AboutPageComponent } from './pages/about-page/about-page.component';
import { EventPageComponent } from './pages/event-page/event-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';

import {AppRoutingModule, LoginGuard} from './routing/app-routing.module';
import { ProfileInfoComponent } from './components/profile-info/profile-info.component';
import { EditPageComponent } from './pages/edit-page/edit-page.component';
import { SignupPageComponent } from './pages/signup-page/signup-page.component';
import {UpdateComponent} from './components/update/update.component';
import {FormsModule} from '@angular/forms';
import {DataService} from './services/data.service';
import {AuthenticationService} from './services/authentication.service';
import {HttpClientModule} from '@angular/common/http';
import {Select2Module} from 'ng2-select2';
import { EventModalComponent } from './components/event-modal/event-modal.component';
import { EventGenericComponent } from './components/event-generic/event-generic.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    IntroSectionComponent,
    FooterComponent,
    EventsSectionComponent,
    LeaderboardSectionComponent,
    FutureEventsSectionComponent,
    PastEventsSectionComponent,
    AboutWebsiteComponent,
    AboutLocationComponent,
    ProfileComponent,
    HomePageComponent,
    AboutPageComponent,
    EventPageComponent,
    ProfilePageComponent,
    ProfileInfoComponent,
    EditPageComponent,
    SignupPageComponent,
    UpdateComponent,
    EventModalComponent,
    EventGenericComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    Select2Module
  ],
  providers: [DataService, LoginGuard, AuthenticationService],
  bootstrap: [AppComponent]
})

export class AppModule { }
