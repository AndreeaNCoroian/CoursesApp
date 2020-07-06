import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AngularMaterialModule } from './shared/angular-material.module'

import { CoreModule } from './core/core.module'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegistrationComponent },

    { path: 'courses', loadChildren: './courses/courses.module#CoursesModule' },

    { path: 'reviews', loadChildren: './reviews/reviews.module#ReviewsModule' },

    { path: 'fetch-data/:courseId', loadChildren: './course/course.module#CoursesModule' },

    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent, },
    { path: 'fetch-data/:courseId', component: CourseDetailsComponent }
]
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CourseDetailsComponent,
    RegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    AngularMaterialModule,
    CoreModule,
    BrowserAnimationsModule
    ],
    exports: [CoreModule, AngularMaterialModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
