
#ifndef DECIDE_H
#define DECIDE_H

#include <array>
#include <vector>
#include <cmath>
enum CONNECTORS { NOTUSED = 777, ORR, ANDD };

// Less than, equal to, greater than
enum COMPTYPE { LT = 1111, EQ, GT };

struct COORDINATE {
  double x;
  double y;
};

struct PARAMETERS_T {
  double LENGTH1; // Length in LICs 0, 7, 12
  double RADIUS1; // Radius in LICs 1, 8, 13
  double EPSILON; // Deviation from PI in LICs 2, 9
  double AREA1;   // Area in LICs 1, 8, 13
  int Q_PTS;      // No. of consecutive points in LIC 4
  int QUADS;      // No. of quadrants in LIC 4
  double DIST;    // Distance in LIC 6
  int N_PTS;      // No. of consecutive pts. in LIC 6
  int K_PTS;      // No. of int. pts. in LICs 7, 12
  int A_PTS;      // No. of int. pts. in LICs 8, 13
  int B_PTS;      // No. of int. pts. in LICs 8, 13
  int C_PTS;      // No. of int. pts. in LIC 9
  int D_PTS;      // No. of int. pts. in LIC 9
  int E_PTS;      // No. of int. pts. in LICS 10, 14
  int F_PTS;      // No. of int. pts. in LICS 10, 14
  int G_PTS;      // No. of int. pts. in LIC 11
  double LENGTH2; // Maximum length in LIC 12
  double RADIUS2; // Maximum radius in LIC 13
  double AREA2;   // Maximum area in LIC 14
};

class Decide {
private:
  // Inputs
  const int NUMPOINTS; // Number of planar data points.
  const std::vector<COORDINATE>
      COORDINATES; // Array containing the coordinates of data points.
  const PARAMETERS_T PARAMETERS; // Struct holding the parameters for LICs.
  const std::array<std::array<CONNECTORS, 15>, 15>
      LCM; // Logical Connector Matrix. IMPORTANT! LCM[y][x] <-- y first then x.
  const std::array<bool, 15> PUV; // Preliminary unlocking vector.

  // Outputs
  bool LAUNCH;
  std::array<bool, 15> CMV; // Conditions Met Vector.
  std::array<std::array<bool, 15>, 15>
      PUM; // Preliminary Unlocking Matrix. IMPORTANT! PUM[y][x] <-- y first
           // then x.
  std::array<bool, 15> FUV; // Final Unlocking Vector.

  // Methods
  // Method for comparing doubles.
  COMPTYPE DOUBLECOMPARE(double A, double B) const;

  // Step 2.1 from specification.
   void Calc_CMV();
   bool Lic4(){
    //CMV[4] = false;
    if (NUMPOINTS<PARAMETERS.Q_PTS)return false;
    for(int i = 0; i < NUMPOINTS-PARAMETERS.Q_PTS+1; i++) {
        bool quadrants[4];
        for(int k=0;k<4;k++) {quadrants[k]=false;}
        int count=0; 
        for(int j = 0; j < PARAMETERS.Q_PTS; j++ ) {
                COORDINATE p = COORDINATES[i+j];
                if(p.x >= 0) {
                  if(p.y >= 0) {quadrants[0] = true;} 
                  else {quadrants[3] = true;} }
                else{ 
                  if(p.y >= 0) {quadrants[1] = true;} 
                  else {quadrants[2] = true;}}}
        for(bool q : quadrants) {if(q) {count +=1;}}    
        if (count>PARAMETERS.Q_PTS){ 
            return true;}  }  
        //CMV[4] = false; 
    return false;     };      
                    
                   
    bool Lic9(){//LIC9
    //CMV[9] = false;
    if (NUMPOINTS<5)return false;
    std::vector<COORDINATE> a;
    
    int c;
    for(int i = 0; i < NUMPOINTS-3; i++) {
        c=0;
        a.clear();

        for(int j = 0; j < 5; j++){
        if((i+j)!=PARAMETERS.C_PTS&&(i+j)!=PARAMETERS.D_PTS){
        a.push_back(COORDINATES[i+j]);
        c++;}
        if(c=3&&(i+j)>=NUMPOINTS-1){c=500;break;}
        if(c=3)break;}

        double angle= acos(((a[0].x-a[1].x)*(a[2].x-a[1].x)+(a[0].y-a[1].y)*(a[2].y-a[1].y))/(sqrt((a[0].x-a[1].x)*(a[0].x-a[1].x)+(a[0].y-a[1].y)*(a[0].y-a[1].y))*sqrt((a[2].x-a[1].x)*(a[2].x-a[1].x)+(a[2].y-a[1].y)*(a[2].y-a[1].y))));
        if(angle<3.1415926535-PARAMETERS.EPSILON||angle>3.1415926535+PARAMETERS.EPSILON){return true;}
        if(c=500)break;
}

    //CMV[9] = false;
    return false;      
};
    bool Lic14(){
    //CMV[14] = false;
    if (NUMPOINTS<5) return false;
    std::vector<COORDINATE> a;
    
    int c;
    for(int i = 0; i < NUMPOINTS-3; i++) {
        c=0;
        a.clear();
        for(int j = 0; j < 5; j++){
        if((i+j)!=PARAMETERS.F_PTS&&(i+j)!=PARAMETERS.E_PTS){
        a.push_back(COORDINATES[i+j]);
        c++;}
        if(c=3&&(i+j)>=NUMPOINTS-1){c=500;break;}
        if(c=3)break;}
        double area= (a[0].x*a[1].y+a[1].x*a[2].y+a[2].x*a[0].y-a[0].x*a[2].y-a[1].x*a[0].y-a[2].x*a[1].y)/2;
        if(area<PARAMETERS.AREA2||area>PARAMETERS.AREA1){return true;}
        if(c=500)break;
}

    //CMV[14] = false;
    return false  ;
    };

  // Step 2.2 from specification.
  void Calc_PUM();

  // Step 2.3 from specification.
  void Calc_FUV(){
    bool a;
    for(int j = 0; j < 15; j++){
      a=PUM[0][j];
      for(int i = 1; i < 15; i++){a&=PUM[i][j];}
      FUV[j]=(!PUV[j])||a;}
  };

  // 2.4 from specification.
  void Calc_LAUNCH();

public:
  Decide(int NUMPOINTS, const std::vector<COORDINATE> &POINTS,
         const PARAMETERS_T &PARAMETERS,
         const std::array<std::array<CONNECTORS, 15>, 15> &LCM,
         const std::array<bool, 15> &PUV);

  // Call functions for 2.1 - 2.4 and print answer to stdout.
  void decide();

  // Debug function that prints all member variables to stdout.
  void debugprint() const;
};

#endif