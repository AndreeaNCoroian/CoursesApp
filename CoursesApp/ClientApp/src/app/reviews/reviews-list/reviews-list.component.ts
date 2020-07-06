import { Component, OnInit } from '@angular/core';
import { Review } from '../reviews.models';
import { ReviewsService } from '../reviews.service';

@Component({
    selector: 'app-reviews-list',
    templateUrl: './reviews-list.component.html',
    styleUrls: ['./reviews-list.component.css']
})
export class ReviewsListComponent implements OnInit {


    public displayedColumns: string[] = ['content', 'courseId', 'action'];
    public reviews: Review[];

    constructor(private reviewsService: ReviewsService) { }

    ngOnInit() {
        this.loadReviews();
    }

    loadReviews() {
        this.reviewsService.listReviews().subscribe(res => {
            this.reviews = res;
        });
    }

    deleteReview(review: Review) {
        this.reviewsService.deleteReview(review.id).subscribe(x => {
            this.loadReviews();
        });
    }
}
