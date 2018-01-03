import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { IntroSectionComponent } from './intro-section/intro-section.component';
import { FooterComponent } from './footer/footer.component';
import { EventsSectionComponent } from './events-section/events-section.component';
import { LeaderboardSectionComponent } from './leaderboard-section/leaderboard-section.component';
import { FutureEventsSectionComponent } from './future-events-section/future-events-section.component';
import { PastEventsSectionComponent } from './past-events-section/past-events-section.component';
import { AboutWebsiteComponent } from './about-website/about-website.component';
import { AboutLocationComponent } from './about-location/about-location.component';


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
    AboutLocationComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
