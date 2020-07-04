import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoursesEditComponent } from './courses-edit/courses-edit.component';
import { CoursesListComponent } from './courses-list/courses-list.component';



@NgModule({
  declarations: [CoursesEditComponent, CoursesListComponent],
  imports: [
    CommonModule
  ]
})
export class CoursesModule { }
