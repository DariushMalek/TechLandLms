import { AuthModel } from './auth.model';
import { AddressModel } from './address.model';
import { SocialNetworksModel } from './social-networks.model';

export class UserModel extends AuthModel {
    id: number;
    userName: string;
    password: string;
    fullname: string;
    email: string;
    pic: string;
    roles: number[];
    occupation: string;
    companyName: string;
    phone: string;
    address?: AddressModel;
    socialNetworks?: SocialNetworksModel;
    // personal information
    firstName: string;
    lastName: string;
    userTitle: string;
    website: string;
    // account information
    language: string;
    timeZone: string;
    communication: {
        email: boolean,
        sms: boolean,
        phone: boolean
    };
    // email settings
    emailSettings: {
        emailNotification: boolean,
        sendCopyToPersonalEmail: boolean,
        activityRelatesEmail: {
            youHaveNewNotifications: boolean,
            youAreSentADirectMessage: boolean,
            someoneAddsYouAsAsAConnection: boolean,
            uponNewOrder: boolean,
            newMembershipApproval: boolean,
            memberRegistration: boolean
        },
        updatesFromKeenthemes: {
            newsAboutKeenthemesProductsAndFeatureUpdates: boolean,
            tipsOnGettingMoreOutOfKeen: boolean,
            thingsYouMissedSindeYouLastLoggedIntoKeen: boolean,
            newsAboutMetronicOnPartnerProductsAndOtherServices: boolean,
            tipsOnMetronicBusinessProducts: boolean
        }
    };

    setUser(user: any) {
        this.id = user.id;
        this.userName = user.userName || '';
        this.password = user.password || '';
        this.fullname = user.fullname || '';
        this.email = user.email || '';
        this.firstName = user.firstName || '';
        this.lastName = user.lastName || '';
        this.pic = user.pic || './assets/media/users/default.jpg';
        this.roles = user.roles || [];
        this.occupation = user.occupation || '';
        this.companyName = user.companyName || '';
        this.phone = user.phone || '';
        this.address = user.address;
        this.socialNetworks = user.socialNetworks;
        this.userTitle = user.firstName +' ' + user.lastName || '';
    }
}
