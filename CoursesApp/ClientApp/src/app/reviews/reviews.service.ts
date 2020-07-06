import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Review } from './reviews.models';
import { ApplicationService } from '../core/services/application.service';


@Injectable()
export class ReviewsService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getReview(id: number) {
        return this.http.get<Review>(`${this.applicationService.baseUrl}api/Reviews/${id}`);
    }

    listReviews() {
        return this.http.get<Review[]>(`${this.applicationService.baseUrl}api/Reviews`);
    }

    saveReviews(review: Review) {
        return this.http.post(`${this.applicationService.baseUrl}api/Reviews`, review);

    }

    modifyReview(review: Review) {
        return this.http.put(`${this.applicationService.baseUrl}api/Reviews/${review.id}`, review);
    }

    deleteReview(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Reviews/${id}`);
    }
}
