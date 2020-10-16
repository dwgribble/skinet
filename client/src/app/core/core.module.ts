import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import {ToastrModule} from 'ngx-toastr';
import { SectionHeaderComponent } from './section-header/section-header.component';
import {BreadcrumbModule} from 'xng-breadcrumb';
import { SharedModule } from '../shared/shared.module';
import { StudentCompletedComponent } from './student-completed/student-completed.component';
import { StudentMyStuffComponent } from './student-my-stuff/student-my-stuff.component';
import { StudentMyTodoComponent } from './student-my-todo/student-my-todo.component';
import { TeacherManageStudentComponent } from './teacher-manage-student/teacher-manage-student.component';
import { TeacherClassHomeComponent } from './teacher-class-home/teacher-class-home.component';
import { TeacherHomeComponent } from './teacher-home/teacher-home.component';
import { TeacherManageClassComponent } from './teacher-manage-class/teacher-manage-class.component';
import { TeacherManageContentComponent } from './teacher-manage-content/teacher-manage-content.component';
import { TeacherManageAssignmentComponent } from './teacher-manage-assignment/teacher-manage-assignment.component';
import { TeacherToolboxComponent } from './teacher-toolbox/teacher-toolbox.component';


@NgModule({
  declarations: [NavBarComponent, TestErrorComponent, NotFoundComponent, ServerErrorComponent, SectionHeaderComponent, StudentCompletedComponent, StudentMyStuffComponent, StudentMyTodoComponent, TeacherManageStudentComponent, TeacherClassHomeComponent, TeacherHomeComponent, TeacherManageClassComponent, TeacherManageContentComponent, TeacherManageAssignmentComponent, TeacherToolboxComponent],
  imports: [
    CommonModule,
    RouterModule,
    BreadcrumbModule,
    SharedModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    })
  ],
  exports: [NavBarComponent, SectionHeaderComponent]
})
export class CoreModule { }
