import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Course } from './courses.models';
import { ApplicationService } from '../core/services/application.service';
import { PaginatedCourses } from './paginatedCourses.models';
import { PageEvent } from '@angular/material/paginator';

@Injectable()

export class CoursesService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getCourse(id: number) {
        return this.http.get<Course>(`${this.applicationService.baseUrl}api/Courses/${id}`);
    }

    listCourses(event?: PageEvent) {
        //send pageIndex, pageSize
        let pageIndex = event ? event.pageIndex + "" : "0";
        let itemsPerPage = event ? event.pageSize + "" : "25";
        console.log(event);
        let params = new HttpParams().set("page", pageIndex).set("itemsPerPage", itemsPerPage); //Create new HttpParams
        return this.http.get<PaginatedCourses>(`${this.applicationService.baseUrl}api/Courses`, { params: params });
    }

    saveCourse(course: Course) {
        return this.http.post(`${this.applicationService.baseUrl}api/Courses`, course);
    }

    modifyCourse(course: Course) {
        return this.http.put(`${this.applicationService.baseUrl}api/Courses/${course.id}`, course);
    }

    deleteCourse(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Courses/${id}`);
    }
}
