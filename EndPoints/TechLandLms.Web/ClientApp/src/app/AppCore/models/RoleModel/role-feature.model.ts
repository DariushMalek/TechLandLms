export class RoleFeature {
    featureName: string;
    featureTitle: string;
    parentFeatureId: number;
    featureId: number;
    roleId: number;
    canInsert: boolean;
    canUpdate: boolean;
    canDelete: boolean;
    canExecute: boolean;
    canRead: boolean;
    subFeatures: RoleFeature[];
}