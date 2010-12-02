project(CSharpBindings)

enable_language(CSharp OPTIONAL)

macro_log_feature(CMAKE_CSharp_COMPILER_LOADED "C# compiler" "Mono or the .NET framework" "http://www.mono-project.com" FALSE "" "Required to compile the C# bindings")

macro_optional_find_package(QScintilla)
macro_log_feature(QSCINTILLA_FOUND "QScintilla2" "QScintilla2 libraries" "http://www.riverbankcomputing.co.uk/software/qscintilla/intro" FALSE "" "Needed to compile QScintilla2 bindings")

macro_optional_find_package(QImageBlitz)
macro_log_feature(QIMAGEBLITZ_FOUND "QImageBlitz" "QImageBlitz library" "http://www.kde.org" FALSE "" "Needed to compile QImageBlitz bindings")

macro_optional_find_package(Phonon)
macro_log_feature(PHONON_FOUND "Phonon" "Phonon multimedia framework" "http://www.kde.org" FALSE "" "Needed to compile Phonon bindings")

macro_optional_find_package(Soprano)
macro_log_feature(SOPRANO_FOUND "Soprano" "Soprano libraries" "http://soprano.sourceforge.net" FALSE "" "Needed to compile Soprano bindings")

macro_optional_find_package(Nepomuk)
macro_log_feature(NEPOMUK_FOUND "Nepomuk" "Nepomuk libraries" "http://www.kde.org" FALSE "" "Needed to compile Nepomuk bindings")

macro_optional_find_package(KdepimLibs)
macro_log_feature(KDEPIMLIBS_FOUND "kdepimlibs" "KDE PIM libraries" "http://www.kde.org" FALSE "" "Needed to compile Akonadi bindings")

macro_optional_find_package(Akonadi)
macro_log_feature(AKONADI_FOUND "Akonadi" "Akonadi libraries" "http://www.kde.org" FALSE "" "Needed to compile Akonadi bindings")

if (NOT CMAKE_CSharp_COMPILER_LOADED)
    return()
endif (NOT CMAKE_CSharp_COMPILER_LOADED)

SET(KEYFILE ${CMAKE_CURRENT_SOURCE_DIR}/key.snk)
SET( UICS_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/qyoto/tools/uics/uics )
SET( CSRCC_EXECUTABLE ${CMAKE_CURRENT_BINARY_DIR}/qyoto/tools/csrcc/csrcc )

macro_optional_add_bindings(QT_QTCORE_FOUND "Qyoto" qyoto)
macro_optional_add_bindings(QT_QTSCRIPT_FOUND "QtScript" qtscript)
macro_optional_add_bindings(QT_QTTEST_FOUND "QtTest" qttest)
macro_optional_add_bindings(QT_QTUITOOLS_FOUND "QtUiTools" qtuitools)
macro_optional_add_bindings(QT_QTWEBKIT_FOUND "QtWebKit" qtwebkit)

macro_optional_add_bindings(PHONON_FOUND "Phonon" phonon)

macro_optional_add_bindings(QSCINTILLA_FOUND "QScintilla" qscintilla)

macro_optional_add_bindings(KDE4_FOUND "Kimono" kimono)
macro_optional_add_bindings(KDE4_FOUND "KHTML" khtml)
macro_optional_add_bindings(KDE4_FOUND "KTextEditor" ktexteditor)
macro_optional_add_bindings(KDE4_FOUND "Plasma" plasma)

macro_optional_add_bindings(Soprano_FOUND "Soprano" soprano)

macro_optional_add_bindings(Nepomuk_FOUND "Nepomuk" nepomuk)

macro_optional_add_bindings(QIMAGEBLITZ_FOUND "QImageBlitz" qimageblitz)

if(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
    set(BUILD_Akonadi TRUE)
else(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
    set(BUILD_Akonadi FALSE)
endif(KDEPIMLIBS_FOUND AND Akonadi_FOUND)
macro_optional_add_bindings(BUILD_Akonadi "Akonadi" akonadi)

macro_display_bindings_log()
