//
//  iOSPlugin.m
//  ObjcMyHaptic
//
//  Created by Soyoung Hyun on 21/11/2019.
//  Copyright © 2019 soyoung hyun. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface iOSPlugin_ : NSObject{
}
//-(void)HapticFeedback:(NSString*)typeName;
@end



@implementation iOSPlugin_

+(void) HapticFeedback:(NSString*)typeName{
    //num += 1;
    if([typeName isEqualToString:@"Soft"]){
        UIImpactFeedbackGenerator * gen = [[UIImpactFeedbackGenerator alloc]initWithStyle:(UIImpactFeedbackStyleLight)];
        [gen impactOccurred];
    }else if ([typeName isEqualToString:@"Heavy"]){
        UIImpactFeedbackGenerator * gen = [[UIImpactFeedbackGenerator alloc]initWithStyle:(UIImpactFeedbackStyleHeavy)];
        [gen impactOccurred];
    }else if ([typeName isEqualToString:@"Light"]){
        UIImpactFeedbackGenerator * gen = [[UIImpactFeedbackGenerator alloc]initWithStyle:(UIImpactFeedbackStyleLight)];
        [gen impactOccurred];
    }else if ([typeName isEqualToString:@"Medium"]){
        UIImpactFeedbackGenerator * gen = [[UIImpactFeedbackGenerator alloc]initWithStyle:(UIImpactFeedbackStyleMedium)];
        [gen impactOccurred];
    }else if ([typeName isEqualToString:@"Rigid"]){
        UIImpactFeedbackGenerator * gen = [[UIImpactFeedbackGenerator alloc]initWithStyle:(UIImpactFeedbackStyleLight)];
        [gen impactOccurred];
    }
}

@end

extern "C"{
void unityHaptic(const char *typeName){
    [iOSPlugin_ HapticFeedback:[NSString stringWithUTF8String:typeName]];
}
}
