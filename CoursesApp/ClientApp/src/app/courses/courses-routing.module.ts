import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CoursesEditComponent } from './courses-edit/courses-edit.component';
import { CoursesListComponent } from './courses-list/courses-list.component';
import { CoursesComponent } from './courses.component';


const routes: Routes = [
    {
        path: '', component: CoursesComponent,
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: CoursesListComponent },
            { path: 'edit/:id', component: CoursesEditComponent },
            { path: 'edit', component: CoursesEditComponent },

      
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CoursesRoutingModule {
    static routedComponents = [CoursesComponent, CoursesListComponent, CoursesEditComponent];
}
