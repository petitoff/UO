package com.uni.lista1.models;

import jakarta.persistence.*;

import java.util.List;

@Entity
public class Klient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String imie;
    private String nazwisko;
    private String pesel;

    @OneToOne
    private Dokument dokument;

    @OneToMany
    private List<Adres> adresy;

    @ManyToMany
    @JoinTable(
            name = "klient_usluga", // Nazwa tabeli pośredniczącej
            joinColumns = @JoinColumn(name = "klient_id"), // Kolumna w tabeli pośredniczącej odnosząca się do tej klasy
            inverseJoinColumns = @JoinColumn(name = "usluga_id") // Kolumna w tabeli pośredniczącej odnosząca się do drugiej klasy
    )
    private List<Usluga> uslugi;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getImie() {
        return imie;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public String getPesel() {
        return pesel;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }

    public List<Usluga> getUslugi() {
        return uslugi;
    }

    public void setUslugi(List<Usluga> uslugi) {
        this.uslugi = uslugi;
    }

    public Dokument getDokument() {
        return dokument;
    }

    public void setDokument(Dokument dokument) {
        this.dokument = dokument;
    }

    public List<Adres> getAdresy() {
        return adresy;
    }

    public void setAdresy(List<Adres> adresy) {
        this.adresy = adresy;
    }

    // Getters and Setters
}
