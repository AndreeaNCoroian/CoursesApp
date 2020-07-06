import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CoursesService } from '../courses.service';
import { Course } from '../courses.models';

@Component({
    selector: 'app-courses-edit',
    templateUrl: './courses-edit.component.html',
    styleUrls: ['./courses-edit.component.css']
})
export class CoursesEditComponent implements OnInit {

    private routerLink: string = '../list';

    private courseID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private coursesService: CoursesService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.courseID = parseInt(this.route.snapshot.params['id']);

        if (this.courseID) {
            this.routerLink = '../../list';

            this.coursesService.getCourse(this.courseID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Course>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let course = this.formGroup.value as Course;

            if (this.isEdit) {
                course.id = this.courseID;

                this.coursesService.modifyCourse(course).subscribe(res => {
                    this.router.navigate(['/courses']);
                });
            } else {

                this.coursesService.saveCourse(course).subscribe(res => {
                    this.router.navigate(['/courses']);
                });
            }
        }
    }

    initForm(course: Course) {
        this.formGroup = this.formBuilder.group({
            name: [course.name, Validators.required],
            category: [course.category, Validators.required],
            difficulty: [course.difficulty, Validators.required],
            durationInMin: [course.durationInMin, Validators.required],
            dateAdded: [course.dateAdded, Validators.required],
            startDate: [course.startDate],
            endDate: [course.endDate]
        });
    }

}
