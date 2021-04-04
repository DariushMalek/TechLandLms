import { EventEmitter, Injectable } from '@angular/core';
import { ChatMessages } from '../../models/ChatMessages/chat-messages.model';
import * as signalR from '@aspnet/signalr';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

    receiveMessage = new EventEmitter<ChatMessages>();
    connectionEstablished = new EventEmitter<Boolean>();

    private connectionIsEstablished = false;
    private _hubConnection: HubConnection;

    constructor() {
        this.createConnection();
        this.registerOnServerEvents();
        this.startConnection();
    }

    sendMessage(message: ChatMessages) {
        this._hubConnection.invoke('SendMessage', message);
    }

    private createConnection() {
        this._hubConnection = new signalR.HubConnectionBuilder().withUrl("/chatter").build();
    }

    private startConnection(): void {
        this._hubConnection
            .start()
            .then(() => {
                this.connectionIsEstablished = true;
                console.log('Hub connection started');
                this.connectionEstablished.emit(true);
            })
            .catch(err => {
                console.log('Error while establishing connection, retrying...');
                setTimeout(function () { this.startConnection(); }, 5000);
            });
    }

    private registerOnServerEvents(): void {
        this._hubConnection.on('ReceiveMessage', (data: any) => {
            this.receiveMessage.emit(data);
        });
    }  

}
