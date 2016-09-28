#include "aruco_unity/dictionary.hpp"
#include "aruco_unity/utility/exception.hpp"
#include <opencv2/imgproc.hpp>

extern "C" {
  // Constructors & Destructors
  cv::Ptr<cv::aruco::Dictionary>* auGetPredefinedDictionary(cv::aruco::PREDEFINED_DICTIONARY_NAME name) {
    cv::Ptr<cv::aruco::Dictionary> ptr = cv::aruco::getPredefinedDictionary(name);
    return new cv::Ptr<cv::aruco::Dictionary>(ptr);
  }
  
  void auDeleteDictionary(cv::Ptr<cv::aruco::Dictionary>* dictionary) {
    delete dictionary;
  }

  // Functions
  void auDictionaryDrawMarker(cv::Ptr<cv::aruco::Dictionary>* dictionary, int id, int sidePixels, cv::Mat* img, int borderBits, cv::Exception* exception) {
    ARUCO_UNITY_TRY_CATCH(exception,
      dictionary->get()->drawMarker(id, sidePixels, *img, borderBits);
    )
  }

  // Variables
  int auGetDictionaryMarkerSize(cv::Ptr<cv::aruco::Dictionary>* dictionary) {
    return dictionary->get()->markerSize;
  }
}