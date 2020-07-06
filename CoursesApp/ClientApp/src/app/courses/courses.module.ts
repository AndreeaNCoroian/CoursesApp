import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { CoursesRoutingModule } from './courses-routing.module';
import { CoursesService } from './courses.service';

@NgModule({
    declarations: [CoursesRoutingModule.routedComponents],
  imports: [
      CommonModule,
      CoursesRoutingModule,
      AngularMaterialModule,
      CoreModule,
      FormsModule,
      ReactiveFormsModule
    ],
    providers: [CoursesService]

})

export class CoursesModule { }
