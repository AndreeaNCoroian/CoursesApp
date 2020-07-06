import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { CoursesService } from '../courses/courses.service';
import { CourseWithDetails } from '../courses/courses.models';

@Component({
    selector: 'app-courses-details',
    templateUrl: './courses-details.component.html',
    styleUrls: ['./courses-details.component.css']
})
export class CoursesDetailsComponent implements OnInit {

    private routerLink: string = '../list';

    private courseID: number;

    private course: CourseWithDetails;


    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private coursesService: CoursesService,
        private http: HttpClient,
        @Inject('BASE_URL')
        private baseUrl: string,) { }


    ngOnInit() {

        this.courseID = parseInt(this.route.snapshot.params['id']);

        if (this.courseID) {
            this.routerLink = '../../list';

            this.http.get<CourseWithDetails>(this.baseUrl + 'api/Courses/' + this.courseID).subscribe(result => {
                this.course = result;
                console.log(this.course);
            }, error => console.error(error));
        }
    }
}
    /*   constructor(
    private http: HttpClient,
    @Inject('BASE_URL')
    private baseUrl: string,
    private route: ActivatedRoute) {
}

    loadCourseDetails(courseId: string) {
        this.http.get<CourseWithDetails>(this.baseUrl + 'api/Courses/' + courseId).subscribe(result => {
            this.course = result;
            console.log(this.course);
        }, error => console.error(error));
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.loadCourseDetails(params.get('courseId'));
        });
    }*/

