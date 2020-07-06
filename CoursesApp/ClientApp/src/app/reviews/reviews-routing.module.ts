import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReviewsComponent } from './reviews.component';
import { ReviewsEditComponent } from './reviews-edit/reviews-edit.component';
import { ReviewsListComponent } from './reviews-list/reviews-list.component';

const routes: Routes = [
    {
        path: '', component: ReviewsComponent,
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: ReviewsListComponent },
            { path: 'edit/:id', component: ReviewsEditComponent },
            { path: 'edit', component: ReviewsEditComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ReviewsRoutingModule {
    static routedComponents = [ReviewsComponent, ReviewsListComponent, ReviewsEditComponent];
}
