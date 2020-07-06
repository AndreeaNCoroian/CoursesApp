import { Component, OnInit } from '@angular/core';

import { Course } from '../courses.models';
import { CoursesService } from '../courses.service';
import { PaginatedCourses } from '../paginatedCourses.models';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {

    public displayedColumns: string[] = ['name', 'category', 'difficulty', 'dateAdded', 'numberOfReviews', 'action'];
    public courses: PaginatedCourses;
    public pageEvent: PageEvent;

    constructor(private coursesService: CoursesService) {
    }

    ngOnInit() {
        this.loadCourses(null);
    }

    loadCourses(event?: PageEvent) {
        this.courses = null;
        this.coursesService.listCourses(event).subscribe(res => {
            this.courses = res;
        });
    }

    deleteCourse(course: Course) {
        this.coursesService.deleteCourse(course.id).subscribe(x => {
            this.loadCourses();
        });
    }

}
