import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from '../pages/home-page/home-page.component';
import {AboutPageComponent} from '../pages/about-page/about-page.component';
import {EventPageComponent} from '../pages/event-page/event-page.component';
import {ProfilePageComponent} from '../pages/profile-page/profile-page.component';
import {SignupPageComponent} from '../pages/signup-page/signup-page.component';
import {EditPageComponent} from '../pages/edit-page/edit-page.component';

const routes: Routes = [
  { path: '',  component: HomePageComponent},
  { path: 'about',  component: AboutPageComponent},
  { path: 'events',  component: EventPageComponent},
  { path: 'profile', component: ProfilePageComponent},
  { path: 'signup', component: SignupPageComponent},
  { path: 'edit', component: EditPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
