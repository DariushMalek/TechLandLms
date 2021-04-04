import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { LayoutService } from '../../../../../core';
import { Observable } from 'rxjs';
import { UserModel } from '../../../../../../modules/auth/_models/user.model';
import { AuthService } from '../../../../../../modules/auth/_services/auth.service';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-offcanvas',
    templateUrl: './user-offcanvas.component.html',
    styleUrls: ['./user-offcanvas.component.scss'],
})
export class UserOffcanvasComponent implements OnInit {
    extrasUserOffcanvasDirection = 'offcanvas-right';
    user$: Observable<UserModel>;
    currentUser: UserModel;
    userProfileImage: any;

    constructor(private layout: LayoutService,
        private auth: AuthService,
        private cdr: ChangeDetectorRef,
        private router: Router) { }

    ngOnInit(): void {
        this.extrasUserOffcanvasDirection = `offcanvas-${this.layout.getProp(
            'extras.user.offcanvas.direction'
        )}`;
        this.user$ = this.auth.currentUserSubject.asObservable();
        this.currentUser = this.auth.currentUserValue;

        this.getUserProfileImg();
    }

    logout() {
        this.auth.logout();
        document.location.reload();
    }

    getUserProfileImg() {
        this.auth.getUserProfileImage()
            .subscribe((data: any) => {
                this.loadImage(data);
            }, (error: any) => {
                console.log(error)
            });
    }

    loadImage(img: File) {
        const mimeType = img.type;
        if (mimeType.match(/image\/*/) == null) {
            return;
        }
        const reader = new FileReader();
        reader.readAsDataURL(img);
        reader.onload = (_event) => {
            this.userProfileImage = reader.result;
            this.cdr.detectChanges();
        }
    }

    editUserProfile() {
        this.router.navigate(['./user-management/app-user/edit/' + this.currentUser.id]);
    }

    changePassword(){
        this.router.navigate(['./user-management/change-password/' + this.currentUser.id]);
    }

}
