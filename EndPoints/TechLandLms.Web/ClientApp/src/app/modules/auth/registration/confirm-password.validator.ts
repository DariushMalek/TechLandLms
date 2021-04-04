import { AbstractControl } from '@angular/forms';

export class ConfirmPasswordValidator {
  /**
   * Check matching password with confirm password
   * @param control AbstractControl
   */
  static MatchPassword(control: AbstractControl) {
    const password = control.get('pass').value;

      const confirmPassword = control.get('confirmPass').value;

    if (password !== confirmPassword) {
        control.get('confirmPass').setErrors({ ConfirmPassword: true });
    } else {
      return null;
    }
  }
}
