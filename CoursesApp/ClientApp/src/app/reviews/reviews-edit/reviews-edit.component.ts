import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ReviewsService } from '../reviews.service';
import { Review } from '../reviews.models';
import { REPLCommand } from 'repl';

@Component({
    selector: 'app-reviews-edit',
    templateUrl: './reviews-edit.component.html',
    styleUrls: ['./reviews-edit.component.css']
})
export class ReviewsEditComponent implements OnInit {

    private routerLink: string = '../list';

    private reviewID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(

        private router: Router,
        private route: ActivatedRoute,
        private reviewsService: ReviewsService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.reviewID = parseInt(this.route.snapshot.params['id']);

        if (this.reviewID) {
            this.routerLink = '../../list';

            this.reviewsService.getReview(this.reviewID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Review>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let review = this.formGroup.value as Review;
          

            if (this.isEdit) {
                review.id = this.reviewID;

                this.reviewsService.modifyReview(review).subscribe(res => {
                    this.router.navigate(['/reviews']);
                });
            } else {

                this.reviewsService.saveReviews(review).subscribe(res => {
                    this.router.navigate(['/reviews']);
                });
            }
        }
    }

    initForm(review: Review) {
        this.formGroup = this.formBuilder.group({
            text: [review.Content, Validators.required],
            courseId: [review.CourseId, Validators.required]
        });
    }

}
