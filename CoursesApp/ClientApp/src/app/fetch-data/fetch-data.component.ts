import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public courses: Course[];
    public name: string = "test";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
      this.loadCourses();
    }

    loadCourses() {
        this.http.get<Course[]>(this.baseUrl + 'api/Courses').subscribe(result => {
            this.courses = result;
            console.log(this.courses);
        }, error => console.error(error));
    }

    delete(courseId: string) {
        if (confirm('Are you sure you want to delete the course with id ' + courseId + '?')) {
            this.http.delete(this.baseUrl + 'api/Courses/' + courseId)
                    .subscribe
                    (
                        result => {
                            alert('Course successfully deleted!');
                            this.loadCourses();
                    },
                     error => alert('Cannot delete course. Maybe it has reviews.')
                    )
        }
    }

    submit() {

        var course: Course = <Course>{};
        course.name = this.name;
        course.category = Category.Finance;
        course.difficulty = Difficulty.Intermediate;
        course.durationInMin = 200;
        course.dateadded = new Date();

        this.http.post(this.baseUrl + 'api/Courses', course).subscribe(result => {
            console.log('Success!');
            this.loadCourses();
        },
        error => {
            if (error.status == 400) {
                console.log(error.error.errors)
            }
        });
    }
}


interface Course {
    id: number;
    name: string;
    category: Category;
    difficulty: Difficulty;
    durationInMin: number;
    dateadded: Date;
    startdate: Date;
    endDate: Date;
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
