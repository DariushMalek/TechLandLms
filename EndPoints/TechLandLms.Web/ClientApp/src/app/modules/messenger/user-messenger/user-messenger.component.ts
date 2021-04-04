import { Component, NgZone } from '@angular/core';
import { ChatMessages } from '../../../AppCore/models/ChatMessages/chat-messages.model';
import { MessengerService } from '../../../AppCore/services/MessengerService/messenger.service';
import { AuthService } from '../../auth/_services/auth.service';

@Component({
  selector: 'app-user-messenger',
  templateUrl: './user-messenger.component.html',
  styleUrls: ['./user-messenger.component.scss']
})
export class UserMessengerComponent {

    title = 'Messenger';
    txtMessage: string = '';
    userName: string = '';
    uniqueID: string = new Date().getTime().toString();
    messages = new Array<ChatMessages>();
    message = new ChatMessages();
    constructor(
        private messengerService: MessengerService,
        private authService: AuthService,
        private _ngZone: NgZone
    ) {
        this.subscribeToEvents();
    }
    sendMessage(): void {
        if (this.txtMessage) {
            this.message = new ChatMessages();
            this.message.clientUniqueId = this.uniqueID;
            this.message.type = "sent";
            this.message.message = this.txtMessage;
            this.message.userName = this.authService.currentUserValue.userName;
            this.message.date = new Date();
            this.messages.push(this.message);
            this.messengerService.sendMessage(this.message);
            this.txtMessage = '';
            this.userName = '';
        }
    }
    private subscribeToEvents(): void {

        this.messengerService.receiveMessage.subscribe((message: ChatMessages) => {
            this._ngZone.run(() => {
                if (message.clientUniqueId !== this.uniqueID) {
                    message.type = "received";
                    this.messages.push(message);
                }
            });
        });
    }

}
