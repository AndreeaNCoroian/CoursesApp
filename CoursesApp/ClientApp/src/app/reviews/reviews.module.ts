import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { ReviewsRoutingModule } from './reviews-routing.module';

import { ReviewsService } from './reviews.service';

@NgModule({
    declarations: [ReviewsRoutingModule.routedComponents],
    imports: [
        CommonModule,
        ReviewsRoutingModule,
        AngularMaterialModule,
        CoreModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [ReviewsService],
})
export class ReviewsModule { }
