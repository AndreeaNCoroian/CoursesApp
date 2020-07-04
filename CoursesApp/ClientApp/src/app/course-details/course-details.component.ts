import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {

    private course: CourseWithDetails;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL')
        private baseUrl: string,
        private route: ActivatedRoute) {
    }

    loadCourse(courseId: string) {
        this.http.get<CourseWithDetails>(this.baseUrl + 'api/Courses/' + courseId).subscribe(result => {
            this.course = result;
            console.log(this.course);
        }, error => console.error(error));
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.loadCourse(params.get('courseId'));
        });
    }

}

interface Review {
    id: number;
    content: string,
   
}

interface CourseWithDetails {
    id: number;
    name: string;
    category: Category;
    difficulty: Difficulty;
    durationInMin: number;
    dateadded: Date;
    startdate: Date;
    endDate: Date;
    review: Review[];
}

enum Category {
    Writing = 0,
    Music = 1,
    Finance = 2,
    Design = 3,
    Photography = 4,
    Culinary = 5,
    Entertainment = 6,
    Society = 7,
    Technology = 8
}
enum Difficulty {
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2
}
