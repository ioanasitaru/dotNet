import {Injectable, NgModule} from '@angular/core';
import {CanActivate, Router, RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from '../pages/home-page/home-page.component';
import {AboutPageComponent} from '../pages/about-page/about-page.component';
import {EventPageComponent} from '../pages/event-page/event-page.component';
import {ProfilePageComponent} from '../pages/profile-page/profile-page.component';
import {SignupPageComponent} from '../pages/signup-page/signup-page.component';
import {EditPageComponent} from '../pages/edit-page/edit-page.component';
import {isNullOrUndefined} from 'util';

@Injectable()
export class LoginGuard implements CanActivate {
  constructor(private router: Router) {}
  canActivate() {
    if (localStorage.getItem('authorization') !== undefined) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}

@Injectable()
export class NotLoginGuard implements CanActivate {
  constructor(private router: Router) {}
  canActivate() {
    if (isNullOrUndefined(localStorage.getItem('authorization'))){
      console.log(localStorage.getItem('authorization'));
      return true;
    }
    this.router.navigate(['']);
    return false;
  }
}


const routes: Routes = [
  { path: '',  component: HomePageComponent},
  { path: 'about',  component: AboutPageComponent},
  { path: 'events',  component: EventPageComponent},
  { path: 'profile', component: ProfilePageComponent, canActivate: [LoginGuard]},
  { path: 'signup', component: SignupPageComponent},
  { path: 'edit', component: EditPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
