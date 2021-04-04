import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent implements OnInit {

    message = this.data.message;
    public refData = { message: this.data.message, isAccept: false }

    constructor(public dialogRef: MatDialogRef<ConfirmDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) { }

    ngOnInit(): void {
        this.refData.isAccept = false;
        this.refData.message = this.data.message;

    }

    closeDialog() {
        this.dialogRef.close();
    }

    accept() {
        this.refData.isAccept = true;
        this.dialogRef.close(this.refData);
    }

    ngOnDestroy() {
        this.dialogRef.close(this.refData);
    }

}
